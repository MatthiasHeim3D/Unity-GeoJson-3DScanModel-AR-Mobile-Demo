using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GeoJsonTest : MonoBehaviour
{
    public List<LineRenderer> lineStrings;
    public List<Transform> PointsOfInterest;

    [ContextMenu("Create GeoJson From LineRenderers And PointsOfInterest")]
    public void CreateGeoJsonFromLineRenderersAndPointsOfInterest()
    {
        List<Feature> features = new List<Feature>();
        foreach (LineRenderer line in lineStrings)
        {
            List<IPosition> linePositions = new List<IPosition>();
            for (int i = 0; i < line.positionCount; i++)
            {
                Vector3 position = line.GetPosition(i);
                linePositions.Add(new Position(position.x, position.z, position.y));
            }
            LineString lineString = new LineString(linePositions);
            Feature lineStringFeature = new Feature(lineString);
            lineStringFeature.Properties.Add("color", ColorToHex(line.startColor));
            lineStringFeature.Properties.Add("width", line.startWidth);
            features.Add(lineStringFeature);
        }

        foreach (Transform point in PointsOfInterest)
        {
            Position position = new Position(point.position.x, point.position.z, point.position.y);
            Point pointGeometry = new Point(position);
            Feature pointFeature = new Feature(pointGeometry);

            var poiColor = point.GetComponent<PoiColor>().color;
            pointFeature.Properties.Add("color", ColorToHex(poiColor));

            features.Add(pointFeature);
        }

        FeatureCollection featureCollection = new FeatureCollection(features);
        string json = JsonConvert.SerializeObject(featureCollection, Formatting.Indented);

        string path = Path.Combine(Application.dataPath, "GeoJsonOutput.json");
        File.WriteAllText(path, json);
        Debug.Log($"GeoJSON saved to {path}");
    }

    string ColorToHex(Color color)
    {
        return $"#{ColorUtility.ToHtmlStringRGBA(color)}";
    }
}
