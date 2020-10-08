#load "nuget:?package=PleOps.Cake&prerelease"

Task("Define-Project")
    .Description("Fill specific project information")
    .Does<BuildInfo>(info =>
{
    info.AddLibraryProjects("Tradusquare.Patcher");
    info.AddApplicationProjects("Tradusquare.Patcher.UI");
    info.AddTestProjects("Tradusquare.Patcher.Tests");
});

Task("Default")
    .IsDependentOn("Stage-Artifacts");

string target = Argument("target", "Default");
RunTarget(target);
