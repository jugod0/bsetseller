class Paginator {
    constructor() {        
        this.data = [];
    }

    setupPagination(config) {
        let pageSize = config.pagesize,
            contentData = config.data;            
        
        while (contentData.length > 0) {
            if (contentData.length < pageSize)
                this.data.push(contentData.splice(0, contentData.length) );
            else {
                this.data.push(contentData.splice(0, pageSize) );
            }                        
        }    
    }

    GetPage(pageNumber) {
        return this.data[pageNumber - 1];
    }

    navigatePage(scope, event) {
        let target = event.target,
            page = event.target.dataset.page;        
        Render.ToMainContent(scope.GetPage(page));
    }

    Render() {
        let template = document.createElement("ul");
        template.id = "pagination";
        for (var i = 0; i < this.data.length; i++) {
            let li = document.createElement("li"),
                page = i + 1;
            li.addEventListener('click', this.navigatePage.bind(this, this));
            li.innerText = page;
            li.dataset.page = page;
            template.appendChild(li);
        }

        return template;
    }

}