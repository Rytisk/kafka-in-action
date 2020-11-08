using System;

namespace UserWebApi.Models
{
    public class UserEvent
    {
        public string UserId { get; set; }
        public string Action { get; set; }

        public static UserEvent Create(string userId) =>
            new UserEvent { UserId = userId, Action = "Create" };

        public static UserEvent Delete(string userId) =>
            new UserEvent { UserId = userId, Action = "Delete" };

        public static UserEvent Update(string userId) =>
            new UserEvent { UserId = userId, Action = "Update" };
    }
}
