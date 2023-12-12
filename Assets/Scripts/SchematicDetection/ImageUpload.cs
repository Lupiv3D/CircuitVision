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


            }
        } );
        Debug.Log( "Permission result: " + permission );
        UI.Instance.compResults[4].GetComponent<Button>().interactable = true;
    }
}
