#r "nuget: Scriban, 5.4.6"

open Scriban

"
namespace Generated.Fsx;

public record Number(int Int, string String) {
    {{- i = 0 }}
    {{- for number in numbers }}
    public static readonly Number {{ string.capitalize number }} = new ({{ ++i }}, \"{{ number }}\");
    {{- end }}
}
"
|> fun template -> Template.Parse(template).Render({| numbers = [| "one"; "two"; "three" |] |})
|> printf "%s"

