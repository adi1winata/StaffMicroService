namespace FSLib.Http
{
    /// <summary>
    /// custom message key
    /// </summary>
    public enum HttpResponseMessageKey
    {
        /// <summary>
        /// 
        /// </summary>
        ArgsNull = 0,
        /// <summary>
        /// 
        /// </summary>
        NotFound = 1,
        /// <summary>
        /// 
        /// </summary>
        DataSuccessfullyCreated = 2,
        /// <summary>
        /// 
        /// </summary>
        DataUnsuccessfullyCreated = 3,
        /// <summary>
        /// 
        /// </summary>
        DataSuccessfullyUpdated = 4,
        /// <summary>
        /// 
        /// </summary>
        DataUnsuccessfullyUpdated = 5,
        /// <summary>
        /// 
        /// </summary>
        DataSuccessfullyDeleted = 6,
        /// <summary>
        /// 
        /// </summary>
        DataUnsuccessfullyDeleted = 7,
        /// <summary>
        /// 
        /// </summary>
        DataHaveReferenced = 8
    }

    /// <summary>
    /// custom http response message
    /// </summary>
    public class FSResponseMessage : FSHttpResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FSResponseMessage() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_responseStatusCodeType"></param>
        /// <param name="_responseStatusMessageType"></param>
        /// <param name="_message"></param>
        public FSResponseMessage(FSStatusCode _responseStatusCodeType, FSStatusMessage _responseStatusMessageType, string _message) : base(_responseStatusCodeType, _responseStatusMessageType)
        {
            status = GetResponseStatusMessage();
            message = _message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_responseStatusCodeType"></param>
        /// <param name="_responseStatusMessageType"></param>
        /// <param name="_key"></param>
        public FSResponseMessage(FSStatusCode _responseStatusCodeType, FSStatusMessage _responseStatusMessageType, HttpResponseMessageKey _key) : base(_responseStatusCodeType, _responseStatusMessageType)
        {
            status = GetResponseStatusMessage();
            message = GetMessage(_key);
        }

        private string GetMessage(HttpResponseMessageKey _key)
        {
            string _message = string.Empty;

            switch (_key)
            {
                case HttpResponseMessageKey.ArgsNull:
                    _message = "Invalid argument or null";
                    break;
                case HttpResponseMessageKey.DataSuccessfullyCreated:
                    _message = "Data successfully created";
                    break;
                case HttpResponseMessageKey.DataSuccessfullyDeleted:
                    _message = "Data successfully deleted";
                    break;
                case HttpResponseMessageKey.DataSuccessfullyUpdated:
                    _message = "Data successfully updated";
                    break;
                case HttpResponseMessageKey.DataUnsuccessfullyCreated:
                    _message = "Data unsuccessfully created";
                    break;
                case HttpResponseMessageKey.DataUnsuccessfullyDeleted:
                    _message = "Data unsuccessfully deleted";
                    break;
                case HttpResponseMessageKey.DataUnsuccessfullyUpdated:
                    _message = "Data unsuccessfully updated";
                    break;
                case HttpResponseMessageKey.NotFound:
                    _message = "Not found";
                    break;
                case HttpResponseMessageKey.DataHaveReferenced:
                    _message = "Data have referenced with another table";
                    break;
                default:
                    _message = string.Empty;
                    break;
            }

            return _message;
        }
    }
}