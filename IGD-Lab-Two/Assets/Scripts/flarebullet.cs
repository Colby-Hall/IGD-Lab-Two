using UnityEngine;
using System.Collections;

public class flarebullet : MonoBehaviour {
			

	private Light flarelight;
	private AudioSource flaresound;
	private ParticleSystemRenderer smokepParSystem;
	private float smooth = 2.4f;
	public 	float flareTimer = 9;
	public AudioClip flareBurningSound;

    public GameObject tree;
    public GameObject deadTree;


	// Use this for initialization
	void Start () {
		
		GetComponent<AudioSource>().PlayOneShot(flareBurningSound);
		flarelight = GetComponent<Light>();
		flaresound = GetComponent<AudioSource>();
		smokepParSystem = GetComponent<ParticleSystemRenderer>();

		
		Destroy(gameObject,flareTimer + 1f);
		
	
	}
	
	// Update is called once per frame
	void Update () {

		
		
		
			flarelight.intensity = Random.Range(2f,6.0f);
			
		
		
			flarelight.intensity =  Mathf.Lerp(flarelight.intensity,0f,Time.deltaTime * smooth);
			flarelight.range =  Mathf.Lerp(flarelight.range,0f,Time.deltaTime * smooth);			
			flaresound.volume = Mathf.Lerp(flaresound.volume,0f,Time.deltaTime * smooth);
        smokepParSystem.maxParticleSize = Mathf.Lerp(smokepParSystem.maxParticleSize, 0f, Time.deltaTime * 5);

			
	}

    private void BurnTree(GameObject other)
    {
        Vector3 treePos = other.transform.position;
        Destroy(other.gameObject);
        Instantiate(deadTree, treePos, Quaternion.identity);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Tree"))
        {
            BurnTree(other.gameObject);
        }
    }


}
