using Bogus;
using Bogus.DataSets;
using System.Diagnostics.Metrics;

namespace BlazorRESTcountries.Models;


public class CountriesResponsV2
{
    public CountryV2[] countries { get; set; }
}

public class CountryV2
{
    public string name { get; set; }
    public string[] topLevelDomain { get; set; }
    public string alpha2Code { get; set; }
    public string alpha3Code { get; set; }
    public string[] callingCodes { get; set; }
    public string capital { get; set; }
    public string[] altSpellings { get; set; }
    public string subregion { get; set; }
    public string region { get; set; }
    public int population { get; set; }
    public float[] latlng { get; set; }
    public string demonym { get; set; }
    public float area { get; set; }
    public float gini { get; set; }
    public string[] timezones { get; set; }
    public string[] borders { get; set; }
    public string nativeName { get; set; }
    public string numericCode { get; set; }
    public Flags flags { get; set; }
    public Currency[] currencies { get; set; }
    public Language[] languages { get; set; }
    public Translations translations { get; set; }
    public string flag { get; set; }
    public Regionalbloc[] regionalBlocs { get; set; }
    public string cioc { get; set; }
    public bool independent { get; set; }

    public static Faker<CountryV2> BogusCountry { get; } = new Faker<CountryV2>()
            .RuleFor(country => country.name, fake => fake.Address.Country())
            .RuleFor(country => country.topLevelDomain, fake => new[] { fake.Internet.DomainSuffix() })
            .RuleFor(country => country.alpha2Code, fake => fake.Address.CountryCode(Iso3166Format.Alpha2))
            .RuleFor(country => country.alpha3Code, fake => fake.Address.CountryCode(Iso3166Format.Alpha3))
            .RuleFor(country => country.callingCodes, fake => new[] { fake.Random.Number(100).ToString() })
            .RuleFor(country => country.capital, fake => fake.Address.City())
            .RuleFor(country => country.altSpellings, fake => new[] { fake.Address.County() })
            .RuleFor(country => country.subregion, fake => fake.Address.State())
            .RuleFor(country => country.region, fake => fake.Address.State())
            .RuleFor(country => country.population, fake => fake.Random.Number(99999999))
            .RuleFor(country => country.latlng, fake => new[] { fake.Random.Float(0f, 180f), fake.Random.Float(0f, 180f) })
            .RuleFor(country => country.demonym, fake => fake.Address.Country())
            .RuleFor(country => country.area, fake => fake.Random.Float(100f, 9999999f))
            .RuleFor(country => country.gini, fake => fake.Random.Float(1f, 100f))
            .RuleFor(country => country.timezones, fake => fake.Random.WordsArray(3))
            .RuleFor(country => country.borders, fake => fake.Random.WordsArray(2))
            .RuleFor(country => country.nativeName, fake => fake.Address.Country())
            .RuleFor(country => country.numericCode, fake => fake.Random.Number(999).ToString())
            .RuleFor(country => country.flags, fake => Flags.BogusFlags.Generate())
            .RuleFor(country => country.currencies, fake => Currency.BobusCurrency.GenerateBetween(1, 3).ToArray())
            .RuleFor(country => country.languages, fake => Language.BobusLanguage.GenerateBetween(1, 2).ToArray())
            .RuleFor(country => country.translations, fake => Translations.BogusTranslation.Generate())
            .RuleFor(country => country.flag, fake => fake.Image.DataUri(200, 200))
            .RuleFor(country => country.regionalBlocs, fake => Regionalbloc.BogusRegionalbloc.GenerateBetween(1, 2).ToArray())
            .RuleFor(country => country.cioc, fake => fake.Address.CountryCode(Iso3166Format.Alpha2))
            .RuleFor(country => country.independent, fake => fake.Random.Bool());
}

public class Flags
{
    public string svg { get; set; }
    public string png { get; set; }

    public static Faker<Flags> BogusFlags { get; } =
        new Faker<Flags>()
        .RuleFor(flag => flag.svg, fake => fake.Image.DataUri(200, 200))
        .RuleFor(flag => flag.png, fake => fake.Image.DataUri(200, 200));
}

public class Translations
{
    public string br { get; set; }
    public string pt { get; set; }
    public string nl { get; set; }
    public string hr { get; set; }
    public string fa { get; set; }
    public string de { get; set; }
    public string es { get; set; }
    public string fr { get; set; }
    public string ja { get; set; }
    public string it { get; set; }
    public string hu { get; set; }

    public static Faker<Translations> BogusTranslation { get; } = new Faker<Translations>()
            .RuleFor(translation => translation.br, fake => fake.Random.String())
            .RuleFor(translation => translation.pt, fake => fake.Random.String())
            .RuleFor(translation => translation.nl, fake => fake.Random.String())
            .RuleFor(translation => translation.hr, fake => fake.Random.String())
            .RuleFor(translation => translation.fa, fake => fake.Random.String())
            .RuleFor(translation => translation.de, fake => fake.Random.String())
            .RuleFor(translation => translation.es, fake => fake.Random.String())
            .RuleFor(translation => translation.fr, fake => fake.Random.String())
            .RuleFor(translation => translation.ja, fake => fake.Random.String())
            .RuleFor(translation => translation.it, fake => fake.Random.String())
            .RuleFor(translation => translation.hu, fake => fake.Random.String());
}

public class Currency
{
    public string code { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }

    public static Faker<Currency> BobusCurrency { get; } = new Faker<Currency>()
            .RuleFor(currancy => currancy.code, fake => fake.Finance.Currency().Code)
            .RuleFor(currancy => currancy.name, fake => fake.Finance.Currency().Description)
            .RuleFor(currancy => currancy.symbol, fake => fake.Finance.Currency().Symbol);
}

public class Language
{
    public string iso639_1 { get; set; }
    public string iso639_2 { get; set; }
    public string name { get; set; }
    public string nativeName { get; set; }

    public static Faker<Language> BobusLanguage { get; } = new Faker<Language>()
            .RuleFor(language => language.iso639_1, fake => fake.Address.CountryCode(Iso3166Format.Alpha2))
            .RuleFor(language => language.iso639_2, fake => fake.Address.CountryCode(Iso3166Format.Alpha3))
            .RuleFor(language => language.name, fake => fake.Address.Country())
            .RuleFor(language => language.nativeName, fake => fake.Address.Country());
}

public class Regionalbloc
{
    public string acronym { get; set; }
    public string name { get; set; }

    public static Faker<Regionalbloc> BogusRegionalbloc { get; } = new Faker<Regionalbloc>()
            .RuleFor(region => region.acronym, fake => fake.Random.String())
            .RuleFor(region => region.name, fake => fake.Random.String());


}
