using System.Collections.Generic;

namespace Grafos.Clases
{
    public class SocialNetwork
    {
        private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        public void AddFriend(string user, string friend)
        {
            if (!graph.ContainsKey(user))
            {
                graph[user] = new List<string>();
            }
            graph[user].Add(friend);
            if (!graph.ContainsKey(friend))
            {
                graph[friend] = new List<string>();
            }
            graph[friend].Add(user);
        }

        public List<string> GetSuggestedFriends(string user)
        {
            List<string> SuggestedFriends = new List<string>();
            foreach (var friend in graph[user])
            {
                foreach (var FriendOfTheFriend in graph[friend])
                {
                    if (FriendOfTheFriend != user && !graph[user].Contains(FriendOfTheFriend) && !SuggestedFriends.Contains(FriendOfTheFriend))
                    {
                        SuggestedFriends.Add(FriendOfTheFriend);
                    }
                }
            }
            return SuggestedFriends;
        }
    }
}