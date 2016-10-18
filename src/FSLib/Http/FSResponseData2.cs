namespace FSLib.Http
{
    /// <summary>
    /// 
    /// </summary>
    public class FSResponseData2<T> : FSHttpResult
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
        public FSResponseData2() { }

        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int cp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_responseStatusCodeType"></param>
        /// <param name="_responseStatusMessageType"></param>
        /// <param name="_data"></param>
        public FSResponseData2(FSStatusCode _responseStatusCodeType, FSStatusMessage _responseStatusMessageType, T _data, int _total, int _cp) : base(_responseStatusCodeType, _responseStatusMessageType)
        {
            status = GetResponseStatusMessage();
            data = _data;
            total = _total;
            cp = _cp;
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
