namespace MaxStore.Models
{
    public class Notification
    {
        public string Message { get; set; }
        public string Type { get; set; }

        public Notification(string message, NotificationType type)
        {
            this.Message = message;
            this.Type = type.ToString().ToLower();
        }
    }
    public enum NotificationType
    {
        Success,
        Error,
        Warning,
        Info
    }
    public enum ActionType
    {
        Created,
        Updated,
        Deleted
    }

}
