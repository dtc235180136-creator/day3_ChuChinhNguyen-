namespace b3_chuchinhnguyen.Controllers
{
    public class ErrorViewModel
    {
        public String? RequestID { get; set;  }
        public bool ShowRequestID => !String.IsNullOrEmpty(RequestID);
    }
}
