using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageUpload : MonoBehaviour
{

    public void upload()
    {
        PickImage(512);
    }
    private void PickImage(int maxSize)
    {

        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
        {
            Debug.Log( "Image path: " + path );
            if( path != null )
            {
                // Create Texture from selected image

                Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );

                Sprite sp = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);

                if( texture == null )
                {
                    Debug.Log( "Couldn't load texture from " + path );
                    return;
                }

                GameObject.FindWithTag("Upload").GetComponent<SpriteRenderer>().sprite = sp;
                UI.Instance.image.sprite = sp;

                // schemDetection._renderTexture = new RenderTexture(texture.width / 2, texture.height / 2, 0);

                // // Assign texture to a temporary quad and destroy it after 5 seconds
                // GameObject quad = GameObject.CreatePrimitive( PrimitiveType.Quad );
                // quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                // quad.transform.forward = Camera.main.transform.forward;
                // quad.transform.localScale = new Vector3( 1, 1, 1);

                // Material material = quad.GetComponent<Renderer>().material;
                // if( !material.shader.isSupported ) // happens when Standard shader is not included in the build
                //     material.shader = Shader.Find( "Legacy Shaders/Diffuse" );

                // material.mainTexture = texture;

                // StartCoroutine(Deactivate(1f));
                // Destroy( quad, 5f );
                // // If a procedural texture is not destroyed manually, 
                // // it will only be freed after a scene change
                // Destroy( texture, 5f );
            }
        } );
        Debug.Log( "Permission result: " + permission );
        UI.Instance.compResults[4].GetComponent<Button>().interactable = true;
    }
}
