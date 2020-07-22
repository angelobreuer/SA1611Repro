// <copyright file="Program.cs" company="PlaceholderCompany">
//     Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SA1611Repro
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     SA1611 Issue Reproduction.
    /// </summary>
    internal sealed class Program
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        /// <summary>
        ///     Gets the content of the specified uri as a stream asynchronously.
        /// </summary>
        /// <param name="uri">the request URI.</param>
        /// <returns>
        ///     A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.
        /// </returns>
        /// <include file="docs.xml" path="/docs/CancellationToken/*"/>
        public Task<Stream> GetContentAsync(Uri uri, CancellationToken cancellationToken = default) // warning SA1611: The documentation for parameter 'cancellationToken' is missing
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (uri is null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            return HttpClient.GetStreamAsync(uri);
        }
    }
}
