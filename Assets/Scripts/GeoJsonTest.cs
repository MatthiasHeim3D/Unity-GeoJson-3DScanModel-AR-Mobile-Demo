using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class GeoJsonTest : MonoBehaviour
{
    void Start()
    {
        Position position = new Position(51.899523, -2.124156);
        Point point = new Point(position);

        List<IPosition> linePositions = new List<IPosition>
        {
            new Position(51.899523, -2.124156),
            new Position(51.899523, -3.124156)
        };
        LineString lineString = new LineString(linePositions);

        Feature pointFeature = new Feature(point);

        pointFeature.Properties.Add("color", ColorToHex(Color.red));

        Feature lineStringFeature = new Feature(lineString);
        lineStringFeature.Properties.Add("color", ColorToHex(Color.blue));

        FeatureCollection featureCollection = new FeatureCollection(new List<Feature> { pointFeature, lineStringFeature });

        string json = JsonConvert.SerializeObject(featureCollection);
        Debug.Log(json);
    }

    string ColorToHex(Color color)
    {
        return $"#{ColorUtility.ToHtmlStringRGBA(color)}";
    }

    Color HexToColor(string hex)
    {
        ColorUtility.TryParseHtmlString(hex, out Color color);
        return color;
    }
}
