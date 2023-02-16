#r "nuget: Scriban, 5.4.6"

using Scriban;

var template = """
namespace Generated.Csx;

public record Number(int Int, string String) {
    {{- i = 0 }}
    {{- for number in numbers }}
    public static readonly Number {{ string.capitalize number }} = new ({{ ++i }}, "{{ number }}");
    {{- end }}
}
""";

var output = Template.Parse(template).Render(new {
    numbers = new [] { "one", "two", "three" }
});

Write(output);