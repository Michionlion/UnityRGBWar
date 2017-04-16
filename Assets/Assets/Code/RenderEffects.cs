using UnityEngine;

public class RenderEffects : MonoBehaviour {

	public Material Bloom;

	public void OnRenderImage(RenderTexture src, RenderTexture dst) {
//		Debug.Log("Applying shader");
		Graphics.Blit(src, dst, Bloom);
	}

}
