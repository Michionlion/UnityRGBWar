using UnityEngine;

public class RenderEffects : MonoBehaviour {

	Material bloom;

	public void OnRenderImage(RenderTexture src, RenderTexture dst) {
		Debug.Log("Applying shader");
		Graphics.Blit(src, dst, bloom);
	}

}
