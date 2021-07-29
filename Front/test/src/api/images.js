import api from "@/api/api";

const URLS = {
    images: "/CountInfo/ImagesInfo",
    image: "/CountInfo/ImageInfo",
}
export const getImages = body => {
    return api.get(URLS.images, body)
}

export const getImage = body => {
    return api.post(URLS.image, body)
}
