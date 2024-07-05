using System;
using UnityEngine;
using System.Collections;
using Unity.Mathematics;

// Create a texture and fill it with Perlin noise.
// Try varying the xOrg, yOrg and scale values in the inspector
// while in Play mode to see the effect they have on the noise.

[System.Serializable]
public class PerlinSource
{
    // The origin of the sampled area in the plane.
    public float xOrg = 128;
    public float yOrg = 128;

    // The number of cycles of the basic noise pattern that are repeated
    // over the width and height of the texture.
    public float scale = 1.0F;
    public float scale2 = 1;
    public float treshold = 0;
    public Color color = Color.red;
}
public class ProceduralPerlin : MonoBehaviour
{
    // Width and height of the texture in pixels.
    public int pixWidth;
    public int pixHeight;

    public PerlinSource[] sources;

    private Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Set up the texture and a Color array to hold pixels during processing.
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.material.mainTexture = noiseTex;
    }

    void CalcNoise()
    {
        Array.Fill(pix, Color.black);
        foreach (var perlinSource in sources)
        {
            // For each pixel in the texture...
            float y = 0.0F;
            while (y < noiseTex.height)
            {
                float x = 0.0F;
                while (x < noiseTex.width)
                {
                    float xCoord = perlinSource.xOrg + x / noiseTex.width * perlinSource.scale;
                    float yCoord = perlinSource.yOrg + y / noiseTex.height * perlinSource.scale;
                    float xCoord2 = perlinSource.xOrg + x / noiseTex.width * perlinSource.scale2;
                    float yCoord2 = perlinSource.yOrg + y / noiseTex.height * perlinSource.scale2;
                    var perlinNoise = (Mathf.PerlinNoise(xCoord, yCoord) - Mathf.PerlinNoise(xCoord2, yCoord2));
                    //var perlinNoise = noise.cellular2x2(new float2() { x = xCoord, y = yCoord }).x - noise.cellular2x2(new float2() { x = xCoord2, y = yCoord2 }).x;
                    float sample = perlinNoise > (perlinSource.treshold) ? Mathf.Pow( Mathf.Clamp01(perlinNoise - perlinSource.treshold), 0.25f) : 0;
                    if (sample > 0)
                    {
                        pix[(int)y * noiseTex.width + (int)x] = perlinSource.color * 1;
                    }
                    x++;
                }
                y++;
            }
        }
        
        // Copy the pixel data to the texture and load it into the GPU.
        noiseTex.SetPixels(pix);
        noiseTex.Apply();
    }

    void Update()
    {
        CalcNoise();
    }
}