namespace Sandbox
{

    public class UserUserInteraction
    {
        public EventObject? Event { get; set; }
        public User Actor { get; set; } = null!;
        public User Target { get; set; } = null!;
        public string InteractionType { get; set; } = null!;
        public string InteractionDescription { get; set; } = null!;
        public UserUserInteraction(User actor, User target, string interactionType, EventObject? event_, string interactionDescription)
        {
            Actor = actor;
            Target = target;
            Event = event_;
            InteractionType = interactionType;
            InteractionDescription = interactionDescription;
        }
    }

}