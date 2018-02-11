using System.Collections;

namespace Assets.scripts.Interfaces
{
    interface IInteractableCorutine
    {
        IEnumerator StartInteract();
        IEnumerator StopInteract();
    }
}
