namespace Application.Core
{
    public class AppException
    {
        public AppException(int status, string message, string details = null)
        {
            StatusCode = status;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}