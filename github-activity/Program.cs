if (args.Length > 0) {
    Console.WriteLine(args[0]);
    await Github.GetUserActivity(args[0]);
}