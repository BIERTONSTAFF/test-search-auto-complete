class Api {
  baseUri = "/api";

  async fetch(path, method, query = undefined, body = undefined) {
    const options = {
      method: method,
      headers: {
        "Content-Type": "application/json",
      },
    };

    if (body) options.body = JSON.stringify(body);

    return await (
      await fetch(this.baseUri + path + (query || ""), options)
    ).json();
  }

  async search(text) {
    return await this.fetch("/notes/search?text=", "GET", text);
  }
}
