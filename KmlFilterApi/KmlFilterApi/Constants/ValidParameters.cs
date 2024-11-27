namespace KmlFilterApi.Constants
{
    public static class ValidParameters
    {
        public static readonly List<string> PreSelection = new List<string>()
        {
            "CLIENTE",
            "SITUAÇÂO",
            "BAIRRO" 
        };


        public static readonly List<string> WithPartialMinimalText = new List<string>() { "REFERENCIA", "RUA/CRUZAMENTO" };
    }
}
