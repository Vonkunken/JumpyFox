using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Vector2 parallaxEffectMultiplier;
    [SerializeField] bool infiniteHorizontal = true;
    [SerializeField] bool infiniteVertical = false;
    private Vector3 lastCameraPosition;
    float textureUnitSizeX;
    float textureUnitSizeY;

    private void Start()
    {
        lastCameraPosition = cameraTransform.position;
        Sprite sprite =  GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit) * transform.localScale.x;
        textureUnitSizeY = (texture.width / sprite.pixelsPerUnit) * transform.localScale.y;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if (infiniteHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y, transform.position.z);
            }
        }
        if (infiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY, transform.position.z);
            }
        }
    }
}
