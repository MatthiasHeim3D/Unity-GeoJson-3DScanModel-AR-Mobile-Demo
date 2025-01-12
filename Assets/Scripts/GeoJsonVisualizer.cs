using GeoJSON.Net.Converters;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GeoJsonVisualizer : MonoBehaviour
{
    public TextAsset geoJsonFile;
    public GameObject pointPrefab;
    public GameObject lineRendererPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (geoJsonFile == null)
        {
            Debug.LogError($"GeoJSON file invalid!");
            return;
        }

        string json = geoJsonFile.text;
        FeatureCollection featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(json);

        GameObject pointsParent = new GameObject("Points");
        pointsParent.transform.SetParent(this.transform, false);

        GameObject lineStringsParent = new GameObject("LineStrings");
        lineStringsParent.transform.SetParent(this.transform, false);

        foreach (Feature feature in featureCollection.Features)
        {
            if (feature.Geometry is Point point)
            {
                Vector3 position = new Vector3((float)point.Coordinates.Latitude, (float)point.Coordinates.Altitude, (float)point.Coordinates.Longitude);
                GameObject pointInstance = Instantiate(pointPrefab, position, Quaternion.identity);
                pointInstance.transform.SetParent(pointsParent.transform, false);

                var color = HexToColor(feature.Properties.TryGetValue("color", out object colorString) ? (string)colorString : "#FFFFFF");
                pointInstance.GetComponent<Renderer>().material.color = color;
            }
            else if (feature.Geometry is LineString lineString)
            {
                GameObject lineInstance = Instantiate(lineRendererPrefab);
                LineRenderer lineRenderer = lineInstance.GetComponent<LineRenderer>();
                lineRenderer.positionCount = lineString.Coordinates.Count;
                Vector3[] positions = new Vector3[lineString.Coordinates.Count];

                for (int i = 0; i < lineString.Coordinates.Count; i++)
                {
                    positions[i] = new Vector3((float)lineString.Coordinates[i].Latitude, (float)lineString.Coordinates[i].Altitude, (float)lineString.Coordinates[i].Longitude);
                }

                lineRenderer.SetPositions(positions);

                var color = HexToColor(feature.Properties.TryGetValue("color", out object colorString) ? (string)colorString : "#FFFFFF");
                lineRenderer.startColor = color;
                lineRenderer.endColor = color;

                var width = feature.Properties.TryGetValue("width", out object widthValue) ? (float)(double)widthValue : 0.1f;
                lineRenderer.startWidth = width;
                lineRenderer.endWidth = width;

                lineInstance.transform.SetParent(lineStringsParent.transform, false);
            }
        }
    }

    Color HexToColor(string hex)
    {
        ColorUtility.TryParseHtmlString(hex, out Color color);
        return color;
    }
}
