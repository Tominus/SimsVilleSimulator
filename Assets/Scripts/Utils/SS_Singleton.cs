using UnityEngine;

public class SS_Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance = null;

    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            Debug.Log("UUUUUUUUUUUUUUUUWUUUUUUUUUUUUUUUU");
            return;
        }
        instance = this as T;
    }
}