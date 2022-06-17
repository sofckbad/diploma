using UnityEngine;


public class Sh : MonoBehaviour
{
    #region Fields
    
    [SerializeField] private Transform s;
    [SerializeField] private Transform e;
    [SerializeField] private float t;
    [SerializeField] private float d;

    private bool i;
    float ct;

    #endregion



    #region Properties

    #endregion



    #region Methods

    private void Start()
    {
        ct = Time.time;
    }


    private void Update()
    {
        var d = Time.time - ct;
        
        if (d > t)
        {
            ct += t;
            i = !i;
            d -= t;
        }
        
        transform.position = i ? Vector3.Lerp(s.position, e.position, d / t) : Vector3.Lerp(e.position, s.position, d / t);
    }

    #endregion
}