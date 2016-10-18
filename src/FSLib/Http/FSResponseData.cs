namespace FSLib.Http
{
    /// <summary>
    /// custom http response data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FSResponseData<T> : FSHttpResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FSResponseData() { }

        ///// <summary>
        ///// 
        ///// </summary>
        //public int total { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public int cp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_responseStatusCodeType"></param>
        /// <param name="_responseStatusMessageType"></param>
        /// <param name="_data"></param>
        public FSResponseData(FSStatusCode _responseStatusCodeType, FSStatusMessage _responseStatusMessageType, T _data) : base(_responseStatusCodeType, _responseStatusMessageType)
        {
            status = GetResponseStatusMessage();
            data = _data;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="_responseStatusCodeType"></param>
        ///// <param name="_responseStatusMessageType"></param>
        ///// <param name="_data"></param>
        ///// <param name="_total"></param>
        ///// <param name="_cp"></param>
        //public FSResponseData(FSStatusCode _responseStatusCodeType, FSStatusMessage _responseStatusMessageType, T _data, int _total, int _cp) : base(_responseStatusCodeType, _responseStatusMessageType)
        //{
        //    status = GetResponseStatusMessage();
        //    data = _data;
        //    total = _total;
        //    cp = _cp;
        //}
    }
}
