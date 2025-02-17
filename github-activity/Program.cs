if (args.Length > 0) {
    var username = args[0];
    Console.WriteLine($"Fetching results for {username}");
    await Github.GetUserActivity(username);
}