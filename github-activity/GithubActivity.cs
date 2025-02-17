public class Actor {
    public string id { get; set; } = "";
    public string login { get; set; } = "";
    public string display_login { get; set; } = "";
    public string gravatar_id { get; set; } = "";
    public string url { get; set; } = "";
    public string avatar_url { get; set; } = "";
}

public class Payload {
    public string repository_id { get; set; } = "";
    public string push_id { get; set; } = "";
    public List<Commit>? commits { get; set; } = [];
}

public class Commit {
    public string sha { get; set; } = "";
    public string message { get; set; } = "";
    public string distinct { get; set; } = "";
    public string url { get; set; } = "";
}
public class Repo {
    public string id { get; set; } = "";
    public string name { get; set; } = "";
    public string url { get; set; } = "";
}
public class GithubActivity {
    public string id { get; set; } = "";
    public string type { get; set; } = "";
    public Actor actor { get; set; } = new ();
    public Payload payload { get; set; } = new ();
    public Repo repo { get; set; } = new ();
}