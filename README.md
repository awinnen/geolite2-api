# geolite2-api

Download GeoLite2 Country binary database from https://dev.maxmind.com/geoip/geoip2/geolite2/#MaxMind_APIs
and adjust path to GeoLite2-Country.mmdb in appsettings.json

Api returns Information about the requesting user if called without param, and Information for 8.8.8.8 ip-address when called with ?ip=8.8.8.8
