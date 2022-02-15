using UnityEngine;
using UnityEditor;

public abstract class SS_CustomTemplateEditor<T> : Editor where T : MonoBehaviour
{
    protected T eTarget = null;
    protected virtual void OnEnable()
    {
        eTarget = (T)target;
    }
}