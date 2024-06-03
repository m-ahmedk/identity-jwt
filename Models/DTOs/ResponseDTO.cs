namespace identity_jwt.Models.DTOs
{
    public record ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ResponseDTO(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
