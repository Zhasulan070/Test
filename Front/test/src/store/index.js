import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

import {getImages, getImage} from "@/api/images";

export default new Vuex.Store({
  state: {
    images: []
  },
  getters: {
    getImages: state => {
      return state.images
    }
  },
  mutations: {
    setImages(state, data) {
       state.images = data
    },
    updateImage(state, data) {
      let arr = [...state.images]
      let index = arr.findIndex(r=> r.id === data.id)
      arr[index] = {...data}
      state.images = arr
    }
  },
  actions: {
    async fetchImages({commit}, params) {
      try {
        let {data} = await getImages(params)
        commit('setImages', data.data)
      } catch (err) {
        console.log(err)
      }
    },
    async updateImage({commit}, params) {
      try {
        let {data} = await getImage(params)
        commit('updateImage', data.data)
      } catch (err) {
        console.log(err)
      }
    }
  },
})
