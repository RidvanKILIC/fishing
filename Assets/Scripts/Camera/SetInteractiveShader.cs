using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractiveShader : MonoBehaviour
{
    [SerializeField] RenderTexture rt;
    [SerializeField] Transform target;
    [SerializeField] GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        Shader.SetGlobalTexture("_GlobalEffectRT", rt);
        Shader.SetGlobalFloat("_OrthographicCamSize", this.gameObject.GetComponent<Camera>().orthographicSize);

        Shader.SetGlobalVector("_Position", target.position);
        particle.transform.position = target.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Shader.SetGlobalVector("_Position", target.position);
        //Vector3.Lerp(particle.transform.position, target.position,0.3f); 
    }
}
