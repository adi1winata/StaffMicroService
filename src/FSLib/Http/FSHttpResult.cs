namespace FSLib.Http
{
    /// <summary>
    /// Custom status code
    /// </summary>
    public enum FSStatusCode
    {
        /// <summary>
        /// Response to a successful GET, PUT, PATCH or DELETE. Can also be used for a POST that doesn't result in a creation.
        /// </summary>
        OK = 200,
        /// <summary>
        /// Response to a POST that results in a creation. Should be combined with a Location header pointing to the location of the new resource
        /// </summary>
        Created = 201,
        /// <summary>
        /// Response to a successfull request that won't be returning a body (like a DELETE request)
        /// </summary>
        NoContent = 204,
        /// <summary>
        /// Used when HTTP caching headers are in play
        /// </summary>
        NotModified = 304,
        /// <summary>
        /// The request is malformed, such as if the body does not parse
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// When no or invalid authentication details are provided. Also useful to trigger an auth popup if the API is used from a browser
        /// </summary>
        Unauthorized = 401,
        /// <summary>
        /// When authentication succeeded but authenticated user doesn't have access to the resource
        /// </summary>
        Forbidden = 403,
        /// <summary>
        /// When a non-existent resource is requested
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// When an HTTP method is being requested that isn't allowed for the authenticated user
        /// </summary>
        MethodNotAllowed = 405,
        /// <summary>
        /// Indicates that the resource at this end point is no longer available. Useful as a blanket response for old API versions
        /// </summary>
        Gone = 410,
        /// <summary>
        /// If incorrect content type was provided as part of the request
        /// </summary>
        UnsupportedMediaType = 415,
        /// <summary>
        /// Used for validation errors
        /// </summary>
        UnprocessableEntity = 422,
        /// <summary>
        /// When a request is rejected due to rate limiting
        /// </summary>
        TooManyRequests = 429,
        /// <summary>
        /// InternalServerErrorException
        /// </summary>
        InternalServerErrorException = 500,
        /// <summary>
        /// ServiceUnavailableException
        /// </summary>
        ServiceUnavailableException = 503
    }

    /// <summary>
    /// custom status message
    /// </summary>
    public enum FSStatusMessage
    {
        /// <summary>
        /// 
        /// </summary>
        success,
        /// <summary>
        /// 
        /// </summary>
        fail,
        /// <summary>
        /// 
        /// </summary>
        error
    }

    /// <summary>
    /// http result
    /// </summary>
    public class FSHttpResult
    {
        /// <summary>
        /// 
        /// </summary>
        protected FSStatusCode responseStatusCodeType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected FSStatusMessage responseStatusMessageType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public FSHttpResult() { }

        /// <summary>
        /// 
        /// </summary>
        public FSHttpResult(FSStatusCode _responseStatusCodeType, FSStatusMessage _responseStatusMessageType)
        {
            responseStatusCodeType = _responseStatusCodeType;
            responseStatusMessageType = _responseStatusMessageType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetResponseStatusMessage()
        {
            return responseStatusMessageType.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetResponseStatusCode()
        {
            return (int)responseStatusCodeType;
        }
    }
}
