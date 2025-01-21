using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IssNow.api
{
    // ISS位置を格納するクラス
    public class IssPosition
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        // 絶対値の緯度を返す
        public double LatitudeAbsolute
        {
            get
            {
                if (double.TryParse(Latitude, out double lat))
                {
                    return Math.Abs(lat);
                }
                return 0; // デフォルト値（必要に応じて調整）
            }
        }

        // 絶対値の経度を返す
        public double LongitudeAbsolute
        {
            get
            {
                if (double.TryParse(Longitude, out double lon))
                {
                    return Math.Abs(lon);
                }
                return 0; // デフォルト値（必要に応じて調整）
            }
        }

        // 緯度の方向（NまたはS）を返す
        public string LatitudeDirection
        {
            get
            {
                if (double.TryParse(Latitude, out double lat))
                {
                    if (lat == 0) return "N"; // 0度はN
                    if (lat == 90) return "N"; // 90度はN
                    if (lat == -90) return "S"; // -90度はS
                    return lat >= 0 ? "N" : "S";
                }
                return "Invalid"; // エラー時の値
            }
        }

        // 経度の方向（EまたはW）を返す
        public string LongitudeDirection
        {
            get
            {
                if (double.TryParse(Longitude, out double lon))
                {
                    if (lon == 0) return "E"; // 0度はE
                    if (lon == 90) return "E"; // 90度はE
                    if (lon == 180 || lon == -180) return "E"; // 180度と-180度はE
                    return lon >= 0 ? "E" : "W";
                }
                return "Invalid"; // エラー時の値
            }
        }
    }
}
