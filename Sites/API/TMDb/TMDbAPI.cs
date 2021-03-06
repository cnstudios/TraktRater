﻿namespace TraktRater.Sites.API.TMDb
{
    using global::TraktRater.Extensions;
    using global::TraktRater.Web;

    /// <summary>
    /// Object that communicates with the TMDb API
    /// </summary>
    public static class TMDbAPI
    {
        /// <summary>
        /// This method is used to generate a valid request token for user based authentication. 
        /// A request token is required in order to request a session id.
        /// </summary>
        public static TMDbTokenResponse RequestToken()
        {
            string response = TraktWeb.TransmitExtended(TMDbURIs.RequestToken);
            return response.FromJSON<TMDbTokenResponse>();
        }

        public static TMDbSessionResponse RequestSessionId(string requestToken)
        {
            string response = TraktWeb.TransmitExtended(string.Format(TMDbURIs.RequestSessionId, requestToken));
            return response.FromJSON<TMDbSessionResponse>();
        }

        public static TMDbAccountInfo GetAccountId(string sessionId)
        {
            string response = TraktWeb.TransmitExtended(string.Format(TMDbURIs.AccountInfo, sessionId));
            return response.FromJSON<TMDbAccountInfo>();
        }

        public static TMDbRatedMovies GetRatedMovies(string accountId, string sessionId, int page)
        {
            string response = TraktWeb.TransmitExtended(string.Format(TMDbURIs.UserRatingsMovies, accountId, sessionId, page.ToString()));
            return response.FromJSON<TMDbRatedMovies>();
        }

        public static TMDbRatedShows GetRatedShows(string accountId, string sessionId, int page)
        {
            string response = TraktWeb.TransmitExtended(string.Format(TMDbURIs.UserRatingsShows, accountId, sessionId, page.ToString()));
            return response.FromJSON<TMDbRatedShows>();
        }

        public static TMDbWatchlistMovies GetWatchlistMovies(string accountId, string sessionId, int page)
        {
            string response = TraktWeb.TransmitExtended(string.Format(TMDbURIs.UserWatchlistMovies, accountId, sessionId, page.ToString()));
            return response.FromJSON<TMDbWatchlistMovies>();
        }

        public static TMDbWatchlistShows GetWatchlistShows(string accountId, string sessionId, int page)
        {
            string response = TraktWeb.TransmitExtended(string.Format(TMDbURIs.UserWatchlistShows, accountId, sessionId, page.ToString()));
            return response.FromJSON<TMDbWatchlistShows>();
        }
    }
}
