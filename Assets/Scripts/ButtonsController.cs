using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ButtonsController : MonoBehaviour
{
    [SerializeField] private string code = "11231";
    [SerializeField] private UnityEvent onActivated;
    [SerializeField] private GameObject image;
    private string curCode;
    bool isActivated;


    public void AddCode(int i)
    {
        if (isActivated)
        {
            return;
        }

        curCode += i.ToString();
        
        if (code.Length < curCode.Length)
        {
            curCode = curCode[^code.Length..];
        }
        
        float val = 0;
        
        for (var i1 = 1; i1 <= code.Length; i1++)
        {
            var s = code[..i1];
            if (curCode.EndsWith(s))
            {
                val = i1;
            }
        }
        
        image.transform.localPosition = new Vector2(image.transform.localPosition.x, 8.4f - 0.9f * val);

        if (curCode.Equals(code))
        {
            isActivated = true;
            onActivated?.Invoke();
        }
    }
}