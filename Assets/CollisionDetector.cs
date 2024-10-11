using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Collider> onTriggerStayEvent = new UnityEvent<Collider>();

    private UnityEvent<Collider> onTriggerExitEvent = new UnityEvent<Collider>();

    private void OnTriggerStay(Collider other)
    {
        //InspectorタブのonTriggerStayEventで指定された処理を実行
        onTriggerStayEvent.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExitEvent.Invoke(other);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
