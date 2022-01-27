using System.Collections.Generic;
using System;
using System.Data;
using System.Text.Json.Nodes;

namespace UnitAppLibrary
{
    public class UnitAppLogic
    {
        public UnitAppLogic()
        { }
        /// <summary>
        /// Método que recorre todo el JSON para mostrar las propiedades en texto 
        /// </summary>
        /// <param name="file">Es el archivo JSON que se va a convertir de string a texto</param>
        /// <returns></returns>
        public bool ReadJSON(string file)
        {
            try
            {
                var fileName = Path.GetFullPath("..\\..\\..\\" + file);
                string jsonString = File.ReadAllText(fileName);
                dynamic? root = JsonNode.Parse(jsonString)?.AsObject();
                List<string> keys = GetListKeys(root);
                for (int i = 0; i < keys.Count; i++)
                {
                    var key = keys[i];
                    var value = root?[key];
                    ConvertStringToText(key, value);
                }
                return true;
            }
            catch (System.IO.FileNotFoundException)
            {
                return false;
            }


        }
        /// <summary>
        /// Método convierte las propiedades del Json "string" a texto.
        /// </summary>
        /// <param name="key">Propiedad del JSON</param>
        /// <param name="value">Valor de la propiedad(key)</param>
        private static void ConvertStringToText(string key, JsonNode value)
        {
            if (value.GetType().ToString() == "System.Text.Json.Nodes.JsonObject")
            {
                var objectKey = GetListValues(value);
                Console.WriteLine(key + ": {");
                GetObjectValue(value, objectKey);
                Console.WriteLine("}");
            }
            else if (value.GetType().ToString() == "System.Text.Json.Nodes.JsonArray")
            {
                Console.WriteLine(key + ": [");
                Console.WriteLine(value);


            }
            else
            {
                Console.WriteLine(key + ": " + value);
            }
        }
        /// <summary>
        /// Método que obtiene los valores de un objeto  y los convierte a texto
        /// </summary>
        /// <param name="objectKeys">Propiedades de un objeto</param>
        /// <param name="value">Valores de las propiedades del objeto</param>
        private static void GetObjectValue(JsonNode value, List<string> objectKeys)
        {
            foreach (string objectKey in objectKeys)
            {
                Console.WriteLine(objectKey + ": " + value[objectKey]);
            }
        }
        /// <summary>
        /// Método que llama al archivo Json para poner a sus hijos(keys) en una lista
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        private static List<string> GetListKeys(JsonObject jsObj)
        {
            List<string> keys = jsObj.AsObject().Select(child => child.Key).ToList();


            return keys;
        }
        /// <summary>
        /// Método que llama al archivo Json para poner los valores de las keys en una lista
        /// </summary>
        /// <param name="jsNode"></param>
        /// <returns></returns>
        private static List<string> GetListValues(JsonNode jsNode)
        {
            List<string> keys = jsNode.AsObject().Select(child => child.Key).ToList();

            return keys;

        }

    }
}
