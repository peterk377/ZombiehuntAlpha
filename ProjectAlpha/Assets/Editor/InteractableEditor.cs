using UnityEditor;

[CustomEditor(typeof(Interactable),true)]

public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.message = EditorGUILayout.TextField("Prompt Message", interactable.message);
            EditorGUILayout.HelpBox("EventOnlyInteractable can ONLY use UnityEvents.", MessageType.Info);
            if (interactable.GetComponent<InteractionEvent>() == null)
                interactable.UseEvents = true;
        }

        else
        {
            base.OnInspectorGUI();
            if (interactable.UseEvents)
            {
                if (interactable.GetComponent<InteractionEvent>() == null)
                    interactable.gameObject.AddComponent<InteractionEvent>();
            }

            else
            {
                if (interactable.GetComponent<InteractionEvent>() != null)
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
            }
        }
    }
}
