class FLib {
    constructor(query) {
        this.e = document.querySelector(query);
    }
    unwrap() {
        return this.e;
    }
    css(props) {
        props.forEach(prop => {
            this.e.style.setProperty(prop[0], prop[1]);
        });
    }
}

const $f = (query) => new FLib(query),
    $fSet = (els = [], props = []) => els.forEach(e => e.css(props));

/*
*
* $e = new FLib('#e');
* e = $e.unwrap();
*
* $e.css([[k, v], [k, v], ..]);
*
* $fSet([..], [[k, v], ..]); :: (els: array; props: array) -> els.forEach(e => e.css(props));
*
* */