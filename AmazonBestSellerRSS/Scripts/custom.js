RSSFeeder = {
    GetFeed: function (feedType, event) {
        Connection.SendRequest("api/amazon/" + feedType);
    }
},
Connection = {
    SendRequest: function (url, data) {
        $.ajax({
            method: "GET",
            url: url,
            success: function(json) {
                let obj = JSON.parse(json);
                window.paginator = new Paginator();
                window.paginator.setupPagination({
                    pagesize: 5,
                    data : obj
                });
                Render.ToMainContent(window.paginator.GetPage(1));
            }
        });
    }
},
Render = {
    ToMainContent: function (contentData) {
        let maincontent = document.getElementById("maincontent"),
            frag = document.createDocumentFragment(),
            contentWrapper = document.createElement("ul");

        maincontent.innerHTML = "";
        frag.appendChild(contentWrapper);
        
        for (var i = 0; i < contentData.length; i++) {
            let content = contentData[i],
                el = document.createElement("li"),
                img = document.createElement("img"),
                title = document.createElement("div"),
                description = document.createElement("div"),
                link = document.createElement("a"),
                detailcontainer = document.createElement("div");

            link.href = content.Link ? content.Link : "";
            link.innerText = "Link";
            description.innerText = content.Description ? content.Description : "";
            title.innerText = content.Title ? content.Title : "";
            img.src = content.ImageUrl ? content.ImageUrl : "";

            detailcontainer.classList.add("details");
            img.classList.add("image");
            link.classList.add("link");
            description.classList.add("description");
            title.classList.add("title");

            detailcontainer.appendChild(title);
            detailcontainer.appendChild(description);
            detailcontainer.appendChild(link);
            el.appendChild(img);
            el.appendChild(detailcontainer);            
            contentWrapper.appendChild(el);
        }        
        maincontent.appendChild(frag);
        maincontent.append(window.paginator.Render());
    }
},    

(function () {
    let sidebarcontent = document.getElementById("sidebar-feed");
    if (sidebarcontent && sidebarcontent.children.length > 0) {
        let sidebarchilds = sidebarcontent.children;

        for (var i = 0; i < sidebarchilds.length; i++) {
            let child = sidebarchilds[i],
                feed = child.dataset.feed;

            child.addEventListener('click', RSSFeeder.GetFeed.bind(this, feed));
        }
    }
})();