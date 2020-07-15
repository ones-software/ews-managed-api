/*
 * Exchange Web Services Managed API
 *
 * Copyright (c) Microsoft Corporation
 * All rights reserved.
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */

namespace Microsoft.Exchange.WebServices.Data
{
    using System;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Represents an implementation of IEwsHttpWebRequestFactory using EwsHttpWebRequest.
    /// </summary>
    internal class EwsHttpWebRequestFactory : IEwsHttpWebRequestFactory
    {
        #region IEwsHttpWebRequestFactory Members

        /// <summary>
        /// Create a new instance of <see cref="EwsHttpWebRequest"/>.
        /// </summary>
        /// <param name="uri">The service URI.</param>
        /// <param name="ignoreCertificate">ignore server certificate error</param>
        /// <returns>An instance of <see cref="IEwsHttpWebRequest"/>./// </returns>
        IEwsHttpWebRequest IEwsHttpWebRequestFactory.CreateRequest(Uri uri, bool ignoreCertificate)
        {
            return new EwsHttpWebRequest(uri, ignoreCertificate);
        }

        /// <summary>
        /// Creates response from a EwsHttpClientException.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>Instance of IEwsHttpWebResponse.</returns>
        IEwsHttpWebResponse IEwsHttpWebRequestFactory.CreateExceptionResponse(EwsHttpClientException exception)
        {
            EwsUtilities.ValidateParam(exception, "exception");

            if (exception.Response == null)
            {
                throw new InvalidOperationException("The exception does not contain response.");
            }

            return new EwsHttpWebResponse(exception.Response);
        }
        #endregion
    }
}