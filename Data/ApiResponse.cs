namespace MoroccoCities.Data
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ApiResponse(bool success, string msg)
        {
            IsSuccess = success;
            Message = msg;
        }
    }
    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse(bool success, T D, string? msg=default(string)):base(success,msg)
        {
            this.Data = D;
            this.Message = msg;
            this.IsSuccess = success;
        }
        public T Data { get; set; }
    }
}
