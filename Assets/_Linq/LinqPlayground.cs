using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Newtonsoft.Json;
using UnityEngine;

public class LinqPlayground : MonoBehaviour
{
    [SerializeField] TextAsset _jsonDocument;

    List<PokemonDto> LoadJson() => JsonConvert.DeserializeObject<List<PokemonDto>>(_jsonDocument.text);

    [Button]
    public void Run()
    {
        var pokedex = LoadJson();
        Debug.Log("Pokedex loaded");


        print(pokedex.Count<PokemonDto>((i) => i.Type.Contains("Psychic")));


        //PokemonDto res = pokedex.Where((i) => i.Type.Contains("Electric")).Aggregate((a, b) =>
        //{
        //    float aWeight = float.Parse(a.Profile.Height.Substring(0, a.Profile.Height.Length - 2));
        //    float bWeight = float.Parse(b.Profile.Height.Substring(0, b.Profile.Height.Length - 2));
        //    return aWeight > bWeight ? a : b;
        //});
        //print(res.Name.English);


        var list = pokedex.OrderBy((a) => a.Base.Attack + a.Base.Defense).Take(10);
        print(list.Count());
    }
}
