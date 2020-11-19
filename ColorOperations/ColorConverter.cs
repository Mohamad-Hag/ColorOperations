using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/// <summary>
/// By: Mohamad Al-Haj Houssein (mohamadhag99@gmail.com)
/// Last Edit In: 5 November 2020
/// </summary>
namespace ColorOperations
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
{
    /// <summary>
    /// ColorConverter contains Collection of methods to convert between the following color modes:
    /// <list type="bullet|number|table">
    /// <item>RGB --> Hex</item>
    /// <item>HEX --> RGB</item>
    /// <item>RGB --> HSL</item>
    /// <item>HSL --> RGB</item>
    /// <item>HEX --> HSL</item>
    /// <item>HSL --> HEX</item>
    /// </list>
    /// </summary>
    public static class ColorConverter
    {
        private static Dictionary<string, double> HexadecimalToDecimalTable = new Dictionary<string, double>();

        /// <summary>
        /// Convert color from RGB values to HSL values.
        /// </summary>
        /// <param name="r">Red parameter in RGB mode.</param>
        /// <param name="g">Green parameter in RGB mode.</param>
        /// <param name="b">Blue parameter in RGB mode.</param>
        /// <returns>Color of type <c>HSL</c>.</returns>
        public static HSL FromRGBToHSL(double r, double g, double b)
        {
            r = r / 255;
            g = g / 255;
            b = b / 255;

            //Calculating Lightness
            double min = Math.Min(r, Math.Min(g, b));
            double max = Math.Max(r, Math.Max(g, b));

            double H = 0;
            double S = 0;
            double L = (min + max) / 2;

            if ((max - min) != 0)
            {
                //Calculating Saturation
                if (min == max)
                    S = 0;
                else
                    S = L <= 0.5 ? ((max - min) / (max + min)) : (max - min) / (2.0 - max - min);

                //Calculating Hue

                if (max == r)
                    H = (g - b) / (max - min);
                else if (max == g)
                    H = 2.0 + (b - r) / (max - min);
                else
                    H = 4.0 + (r - g) / (max - min);

            }
            //Convert hue to dagrees
            double h = Math.Round(H * 60);
            if (H < 0) H += 360;

            //Convert saturation to percentage
            double s = Math.Round(S * 100);

            //Convert lightness (luminace) to percentage
            double l = Math.Round(L * 100);

            HSL hsl = new HSL(h, s, l);
            return hsl;
        }
        /// <summary>
        /// Convert color from HSL values to RGB values.
        /// </summary>
        /// <param name="h">Hue parameter in HSL mode.</param>
        /// <param name="s">Saturation parameter in HSL mode.</param>
        /// <param name="l">Lightness (Luminance) parameter in HSL mode.</param>
        /// <returns>Color of type <c>RGB</c>.</returns>
        public static RGB FromHSLToRGB(double h, double s, double l)
        {
            double R = 0;
            double G = 0;
            double B = 0;
            s = s / 100;
            l = l / 100;
            if (h == 0 && s == 0)
                R = G = B = l * 255;
            else
            {
                double C = (1 - Math.Abs(2 * l - 1)) * s;
                double X = C * (1 - Math.Abs((h / 60) % 2 - 1));
                double m = l - C / 2;

                double _R = 0;
                double _G = 0;
                double _B = 0;
                if (h >= 0 && h < 60)
                {
                    _R = C;
                    _G = X;
                    _B = 0;
                }
                else if (h >= 60 && h < 120)
                {
                    _R = X;
                    _G = C;
                    _B = 0;
                }
                else if (h >= 120 && h < 180)
                {
                    _R = 0;
                    _G = C;
                    _B = X;
                }
                else if (h >= 180 && h < 240)
                {
                    _R = 0;
                    _G = X;
                    _B = C;
                }
                else if (h >= 240 && h < 300)
                {
                    _R = X;
                    _G = 0;
                    _B = C;
                }
                else if (h >= 300 && h < 360)
                {
                    _R = C;
                    _G = 0;
                    _B = X;
                }
                R = (_R + m) * 255;
                G = (_G + m) * 255;
                B = (_B + m) * 255;
            }
            RGB rgb = new RGB(R, G, B);
            return rgb;
        }
        /// <summary>
        /// Convert color from RGB values to HEX values.
        /// </summary>
        /// <param name="r">Red parameter in RGB mode.</param>
        /// <param name="g">Green parameter in RGB mode.</param>
        /// <param name="b">Blue parameter in RGB mode.</param>
        /// <returns>Color of type <c>HEX</c>.</returns>
        public static HEX FromRGBToHEX(double r, double g, double b)
        {
            System.Drawing.Color c = System.Drawing.Color.FromArgb((int)r, (int)g, (int)b);
            HEX hex = new HEX(c.R.ToString("X2"), c.G.ToString("X2"), c.B.ToString("X2"));
            return hex;
        }
        /// <summary>
        /// Convert color from HSL values to HEX values.
        /// </summary>
        /// <param name="h">Hue parameter in HSL mode.</param>
        /// <param name="s">Saturation parameter in HSL mode.</param>
        /// <param name="l">Lightness (Luminance) parameter in HSL mode.</param>
        /// <returns>Color of type <c>HEX</c>.</returns>
        public static HEX FromHSLToHex(double h, double s, int l)
        {
            RGB rgb = FromHSLToRGB(h, s, l);
            HEX hex = FromRGBToHEX(rgb.R, rgb.G, rgb.B);
            return hex;
        }
        /// <summary>
        /// Convert color from Hex values to RGB values.
        /// </summary>
        /// <param name="hex">Hex code parameter in hex mode.</param>
        /// <returns>Color of type <c>RGB</c>.</returns>
        public static RGB FromHexToRGB(string hex)
        {
            #region Hex Code Filter
            //If code empty fill it with "000000".
            if (hex == string.Empty)
                hex = "000000";

            //If hex code starts with "#" remove this "#".
            if (hex.StartsWith("#"))
                hex = hex.Remove(0, 1);

            //If code length bigger than 6 just cut the first 6 number and stored in "hex" variable.
            //If code length smaller than 6 just add zeros to the rest of 6 digits and store it in "hex" variable.
            if (hex.Length > 6)
            {
                hex = hex.Substring(0, 6);
            }
            else if (hex.Length < 6)
            {
                int l = 6 - hex.Length;
                for (int i = 0; i < l; i++)
                {
                    hex += 0;
                }
            }

            //Convert hex code to uppercase to satisfying hexadecimal table keys (A, B, C, D, F) because it's stored as uppercases.
            hex = hex.ToUpper();
            #endregion
            FillHexadecimalToDecimalTable();
            HexadecimalToDecimalTable.TryGetValue(hex[0].ToString(), out double r1);
            HexadecimalToDecimalTable.TryGetValue(hex[1].ToString(), out double r2);
            double R = (r1 * Math.Pow(16, 1)) + (r2 * Math.Pow(16, 0));

            HexadecimalToDecimalTable.TryGetValue(hex[2].ToString(), out double g1);
            HexadecimalToDecimalTable.TryGetValue(hex[3].ToString(), out double g2);
            double G = (g1 * Math.Pow(16, 1) + (g2 * Math.Pow(16, 0)));

            HexadecimalToDecimalTable.TryGetValue(hex[4].ToString(), out double b1);
            HexadecimalToDecimalTable.TryGetValue(hex[5].ToString(), out double b2);
            double B = (b1 * Math.Pow(16, 1)) + (b2 * Math.Pow(16, 0));

            RGB rgb = new RGB(R, G, B);
            return rgb;
        }
        /// <summary>
        /// Convert color from Hex values to HSL values.
        /// </summary>
        /// <param name="hex">Hex code parameter in hex mode.</param>
        /// <returns>Color of type <c>HSL</c>.</returns>
        public static HSL FromHexToHSL(string hex)
        {
            RGB rgb = FromHexToRGB(hex);
            HSL hsl = FromRGBToHSL(rgb.R, rgb.G, rgb.B);
            return hsl;
        }
        /// <summary>
        /// Fill the hexa decimal table (of type Dictionary) with key-value pairs.
        /// Contents of hexa decimal table:
        /// <para>Key | Value</para>
        /// <para>===========</para>
        /// <para>0   | 0</para>
        /// <para>1   | 1</para>
        /// <para>2   | 2</para>
        /// <para>3   | 3</para>
        /// <para>4   | 4</para>
        /// <para>5   | 5</para>
        /// <para>6   | 6</para>
        /// <para>7   | 7</para>
        /// <para>8   | 8</para> 
        /// <para>9   | 9</para>
        /// <para>A   | 10</para>
        /// <para>B   | 11</para>
        /// <para>C   | 12</para>
        /// <para>D   | 13</para>
        /// <para>E   | 14</para>
        /// <para>F   | 15</para>
        /// ===========
        /// </summary>
        private static void FillHexadecimalToDecimalTable()
        {
            HexadecimalToDecimalTable.Clear();
            HexadecimalToDecimalTable.Add("0", 0);
            HexadecimalToDecimalTable.Add("1", 1);
            HexadecimalToDecimalTable.Add("2", 2);
            HexadecimalToDecimalTable.Add("3", 3);
            HexadecimalToDecimalTable.Add("4", 4);
            HexadecimalToDecimalTable.Add("5", 5);
            HexadecimalToDecimalTable.Add("6", 6);
            HexadecimalToDecimalTable.Add("7", 7);
            HexadecimalToDecimalTable.Add("8", 8);
            HexadecimalToDecimalTable.Add("9", 9);
            HexadecimalToDecimalTable.Add("A", 10);
            HexadecimalToDecimalTable.Add("B", 11);
            HexadecimalToDecimalTable.Add("C", 12);
            HexadecimalToDecimalTable.Add("D", 13);
            HexadecimalToDecimalTable.Add("E", 14);
            HexadecimalToDecimalTable.Add("F", 15);
        }
    }

}
