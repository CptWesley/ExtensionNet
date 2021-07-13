using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ExtensionNet
{
    /// <summary>
    /// Provides extension methods that deal with asynchronous things.
    /// Adapted after https://medium.com/@cilliemalan/how-to-await-a-cancellation-token-in-c-cbfc88f28fa2.
    /// </summary>
    public static class AsyncExtensions
    {
        /// <summary>
        /// Allows a cancellation token to be awaited.
        /// </summary>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The waiter for the cancellation token to be cancelled.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CancellationTokenAwaiter GetAwaiter(this CancellationToken ct)
            => new CancellationTokenAwaiter(ct);

        /// <summary>
        /// Gets a task that waits for the token to be cancelled.
        /// </summary>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The task that waits.</returns>
        public static async Task Task(this CancellationToken ct)
            => await ct;

        /// <summary>
        /// The awaiter for cancellation tokens.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct CancellationTokenAwaiter : INotifyCompletion, ICriticalNotifyCompletion
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CancellationTokenAwaiter"/> struct.
            /// </summary>
            /// <param name="cancellationToken">The cancellation token.</param>
            public CancellationTokenAwaiter(CancellationToken cancellationToken)
                => CancellationToken = cancellationToken;

            /// <summary>
            /// Gets the cancellation token.
            /// </summary>
            public CancellationToken CancellationToken { get; }

            /// <summary>
            /// Gets a value indicating whether the cancellation has been requested.
            /// </summary>
            public bool IsCompleted => CancellationToken.IsCancellationRequested;

            /// <summary>
            /// Used to obtain a resulting value from completion.
            /// </summary>
            /// <returns>A different exception depending on the state of the program.</returns>
            public object GetResult()
                => throw (IsCompleted ? new OperationCanceledException() : new InvalidOperationException("The cancellation token has not yet been cancelled."));

            /// <inheritdoc/>
            public void OnCompleted(Action continuation) =>
                CancellationToken.Register(continuation);

            /// <inheritdoc/>
            public void UnsafeOnCompleted(Action continuation) =>
                CancellationToken.Register(continuation);
        }
    }
}
