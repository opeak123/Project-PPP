using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
{
    #region SINGLETONE
    private static T Inst;

    public static T Instance 
    {
        get 
        { 
            if(Inst == null)
            {
                Inst = (T)FindObjectOfType(typeof(T));

                if(Inst == null )
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    Inst = obj.GetComponent<T>();
                }
            }
            return Inst;
        } 
    }

    private void Awake()
    {
        if (transform.parent != null && transform.root != null)
        {
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion

    public void TimeTik()
    {

    }
}
