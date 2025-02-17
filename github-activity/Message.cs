using System.Runtime.CompilerServices;

internal static class Message {
    public static void Print(GithubActivity[] data) {
        Dictionary<string, Dictionary<string, int>> repos = new Dictionary<string, Dictionary<string, int>>();

        foreach(var item in data) {
            var repo = item.repo.name;
            var _event = item.type;
            var commits = item?.payload?.commits?.Count;
            if (!repos.ContainsKey(repo)) {
                repos.Add(repo, new Dictionary<string, int> {
                    { _event, commits ?? 0 }
                });
            }
            else {
                if (!repos[repo].ContainsKey(_event)) {
                    repos[repo].Add(_event, commits ?? 0);
                }
                else {
                    repos[repo][_event] += commits ?? 0;
                }
            }
        } 

        foreach(string repo in repos.Keys) {
            foreach(var _event in repos[repo].Keys) {
                switch(_event) {
                    case "PushEvent":
                        Console.WriteLine($"Pushed {repos[repo][_event]} to {repo}");
                        break;
                    case "CommitCommentEvent":
                        Console.WriteLine($"Created commit comment on {repo}");
                        break;
                    case "CreateEvent":
                        Console.WriteLine($"Create event created on {repo}");
                        break;
                    case "DeleteEvent":
                        Console.WriteLine($"Deleted repo {repo}");
                        break;
                    case "ForkEvent":
                        Console.WriteLine($"Repo {repo} was forked");
                        break;
                    case "GollumEvent":
                        Console.WriteLine($"A wiki page was created for {repo}");
                        break;
                    case "IssueCommentEvent":
                        Console.WriteLine($"Issue commented on {repo}");
                        break;
                    case "IssuesEvent":
                        Console.WriteLine($"Issue created on {repo}");
                        break;
                    case "MemberEvent":
                        Console.WriteLine($"Member activity updated on {repo}");
                        break;
                    case "PublicEvent":
                        Console.WriteLine($"{repo} is updated to be public");
                        break;
                    case "PullRequestEvent":
                        Console.WriteLine($"Pull requested updated on {repo}");
                        break;
                    case "WatchEvent":
                        Console.WriteLine($"{repo} was starred");
                        break;
                }
            }
        }
    }
}