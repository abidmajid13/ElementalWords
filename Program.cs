// Elemental words Kata - Abid Majid
class Program
{
    static void Main()
    {
        // Test cases
        PrintResults("yes");
        PrintResults("snack");
        PrintResults("beach");
        PrintResults("xyz"); // should return nothing
    }

    static void PrintResults(string word)
    {
        Console.WriteLine($"\nWord: {word}");
        var results = ElementalForms(word);

        if (results.Length == 0)
        {
            Console.WriteLine("No elemental forms found.");
        }
        else
        {
            foreach (var form in results)
            {
                Console.WriteLine(string.Join(" + ", form));
            }
        }
    }

    public static string[][] ElementalForms(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return []; 

        // dictionary of elements
        var elements = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "H", "Hydrogen" },
            { "He", "Helium" },
            { "Li", "Lithium" },
            { "Be", "Beryllium" },
            { "B", "Boron" },
            { "C", "Carbon" },
            { "N", "Nitrogen" },
            { "O", "Oxygen" },
            { "F", "Fluorine" },
            { "Ne", "Neon" },
            { "Na", "Sodium" },
            { "Mg", "Magnesium" },
            { "Al", "Aluminium" },
            { "Si", "Silicon" },
            { "P", "Phosphorus" },
            { "S", "Sulfur" },
            { "Cl", "Chlorine" },
            { "Ar", "Argon" },
            { "K", "Potassium" },
            { "Ca", "Calcium" },
            { "Sc", "Scandium" },
            { "Ti", "Titanium" },
            { "V", "Vanadium" },
            { "Cr", "Chromium" },
            { "Mn", "Manganese" },
            { "Fe", "Iron" },
            { "Co", "Cobalt" },
            { "Ni", "Nickel" },
            { "Cu", "Copper" },
            { "Zn", "Zinc" },
            { "Ga", "Gallium" },
            { "Ge", "Germanium" },
            { "As", "Arsenic" },
            { "Se", "Selenium" },
            { "Br", "Bromine" },
            { "Kr", "Krypton" },
            { "Rb", "Rubidium" },
            { "Sr", "Strontium" },
            { "Y", "Yttrium" },
            { "Zr", "Zirconium" },
            { "Nb", "Niobium" },
            { "Mo", "Molybdenum" },
            { "Tc", "Technetium" },
            { "Ru", "Ruthenium" },
            { "Rh", "Rhodium" },
            { "Pd", "Palladium" },
            { "Ag", "Silver" },
            { "Cd", "Cadmium" },
            { "In", "Indium" },
            { "Sn", "Tin" },
            { "Sb", "Antimony" },
            { "Te", "Tellurium" },
            { "I", "Iodine" },
            { "Xe", "Xenon" },
            { "Cs", "Caesium" },
            { "Ba", "Barium" },
            { "La", "Lanthanum" },
            { "Ce", "Cerium" },
            { "Pr", "Praseodymium" },
            { "Nd", "Neodymium" },
            { "Pm", "Promethium" },
            { "Sm", "Samarium" },
            { "Eu", "Europium" },
            { "Gd", "Gadolinium" },
            { "Tb", "Terbium" },
            { "Dy", "Dysprosium" },
            { "Ho", "Holmium" },
            { "Er", "Erbium" },
            { "Tm", "Thulium" },
            { "Yb", "Ytterbium" },
            { "Lu", "Lutetium" },
            { "Hf", "Hafnium" },
            { "Ta", "Tantalum" },
            { "W", "Tungsten" },
            { "Re", "Rhenium" },
            { "Os", "Osmium" },
            { "Ir", "Iridium" },
            { "Pt", "Platinum" },
            { "Au", "Gold" },
            { "Hg", "Mercury" },
            { "Tl", "Thallium" },
            { "Pb", "Lead" },
            { "Bi", "Bismuth" },
            { "Po", "Polonium" },
            { "At", "Astatine" },
            { "Rn", "Radon" },
            { "Fr", "Francium" },
            { "Ra", "Radium" },
            { "Ac", "Actinium" },
            { "Th", "Thorium" },
            { "Pa", "Protactinium" },
            { "U", "Uranium" },
            { "Np", "Neptunium" },
            { "Pu", "Plutonium" },
            { "Am", "Americium" },
            { "Cm", "Curium" },
            { "Bk", "Berkelium" },
            { "Cf", "Californium" },
            { "Es", "Einsteinium" },
            { "Fm", "Fermium" },
            { "Md", "Mendelevium" },
            { "No", "Nobelium" },
            { "Lr", "Lawrencium" },
            { "Rf", "Rutherfordium" },
            { "Db", "Dubnium" },
            { "Sg", "Seaborgium" },
            { "Bh", "Bohrium" },
            { "Hs", "Hassium" },
            { "Mt", "Meitnerium" },
            { "Ds", "Darmstadtium" },
            { "Rg", "Roentgenium" },
            { "Cn", "Copernicium" },
            { "Uut", "Ununtrium" },   // 113
            { "Fl", "Flerovium" },
            { "Uup", "Ununpentium" }, // 115
            { "Lv", "Livermorium" },
            { "Uus", "Ununseptium" }, // 117
            { "Uuo", "Ununoctium" }   // 118
        };

        var results = new List<List<string>>();
        Search(word.ToLower(), new List<string>(), results, elements);

        return results.Select(r => r.ToArray()).ToArray();
    }

    private static void Search(string remainingWord, List<string> wordInElements, List<List<string>> results, Dictionary<string, string> elements)
    {
        if (remainingWord.Length == 0)
        {
            results.Add(new List<string>(wordInElements));
            return;
        }

        for (int symbolLength = 1; symbolLength <= 3 && symbolLength <= remainingWord.Length; symbolLength++)
        {
            string chunk = remainingWord.Substring(0, symbolLength);

            if (elements.TryGetValue(chunk, out var elementName))
            {
                wordInElements.Add($"{elementName} ({chunk})");
                Search(remainingWord.Substring(symbolLength), wordInElements, results, elements);
                wordInElements.RemoveAt(wordInElements.Count - 1);
            }
        }
    }
}

