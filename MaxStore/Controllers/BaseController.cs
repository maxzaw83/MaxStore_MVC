using MaxStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace MaxStore.Controllers
{
    public class BaseController : Controller
    {
        public void Notify(string message, NotificationType type)
        {
            var notification = new Notification(message, type);
            TempData["notification"] = JsonConvert.SerializeObject(notification);
        }
        /// <summary>
        /// NEW: A helper for creating standardized success/error messages.
        /// </summary>
        /// <param name="modelName">The name of the entity (e.g., "Category", "Product").</param>
        /// <param name="action">The action performed (e.g., "created", "updated", "deleted").</param>
        /// <param name="type">The notification type (Success, Error, etc.).</param>
        public void Notify(string modelName, ActionType action, NotificationType type)
        {
            // Convert the enum to a lowercase string for the message
            var actionText = action.ToString().ToLower();

            var message = $"{modelName} {actionText} successfully.";

            // Handle a failure case more gracefully
            if (type == NotificationType.Error)
            {
                message = $"There was an error. {modelName} could not be {actionText}.";
            }

            var notification = new Notification(message, type);
            TempData["notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
